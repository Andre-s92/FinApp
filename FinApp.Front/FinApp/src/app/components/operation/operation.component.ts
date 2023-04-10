import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormArrayName,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { FinancialReleaseModel } from 'src/app/models/financialReleaseModel';
import { OperationModel, StatusOperation } from 'src/app/models/operationModel';
import { OperationService } from 'src/app/services/operation.service';
import { ToastrService } from 'ngx-toastr';
defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-operation',
  templateUrl: './operation.component.html',
  styleUrls: ['./operation.component.scss'],
})
export class OperationComponent implements OnInit {
  financialReleaseForm = new FormGroup({
    id: new FormControl<number>(0, [Validators.required]),
    operationId: new FormControl<number>(0, [Validators.required]),
    cnpj: new FormControl<string>('', [Validators.required]),
    name: new FormControl<string>('', [
      Validators.required,
      Validators.min(8),
      Validators.max(150),
    ]),
    phone: new FormControl<string>('', [Validators.required]),
    zipCode: new FormControl<string>('', [Validators.required]),
    address: new FormControl<string>('', [Validators.required]),
    state: new FormControl<string>('', [Validators.required]),
    city: new FormControl<string>('', [Validators.required]),
    district: new FormControl<string>('', [Validators.required]),
    releaseDate: new FormControl<Date>(new Date(), [Validators.required]),
    dueDate: new FormControl<Date>(new Date(), [Validators.required]),
    discount: new FormControl<number>(0, [Validators.required]),
    amount: new FormControl<number>(0, [Validators.required]),
    number: new FormControl<string>('', [Validators.required]),
  });
  operationForm = new FormGroup({
    id: new FormControl<number>(0),
    status: new FormControl<string | null>('', [Validators.required]),
    description: new FormControl<string | null>('', [Validators.required]),
    financialRelease: new FormControl<FinancialReleaseModel[]>([]),
  });
  currentTitle: number | null = null;
  operationId: number | null = null;
  financialReleaseList: any[] = [];
  operation = {} as OperationModel;

  constructor(
    private localeService: BsLocaleService,
    private operationService: OperationService,
    private router: Router,
    private toastr: ToastrService,
    private activatedRouter: ActivatedRoute,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.loadOperation();
  }
  onTitleSubmit() {
    if (!this.currentTitle) {
      const data = this.financialReleaseForm.value;
      this.financialReleaseList.push(data);
    } else {
      this.financialReleaseList[this.currentTitle - 1] =
        this.financialReleaseForm.value;
      this.currentTitle = null;
    }
    this.financialReleaseForm.reset({
      id: 0,
      operationId: 0,
      cnpj: '',
      name: '',
      phone: '',
      zipCode: '',
      address: '',
      state: '',
      city: '',
      district: '',
      releaseDate: new Date(),
      dueDate: new Date(),
      discount: 0,
      amount: 0,
      number: '',
    });
  }
  onPushSubmit() {
    const operation: OperationModel = {
      id: this.operationId || 0,
      status: StatusOperation.ENVIANDO,
      description: this.financialReleaseList[0].name,
      financialRelease: this.financialReleaseList,
    };
    if (this.operationId) {
      this.operationService.put(operation).subscribe({
        next: (operation: OperationModel) => {
          this.toastr.success('Operação alterada com sucesso!', 'Sucesso');
          this.router.navigate(['/']);
        },
        error: (error: any) => {
          this.toastr.error('Erro ao alterar operação', 'Erro!');
        },
      });
    } else {
      this.operationService.post(operation).subscribe({
        next: (operation: OperationModel) => {
          this.toastr.success('Operação salva com sucesso!', 'Sucesso');
          this.router.navigate(['/']);
        },
        error: (error: any) => {
          this.toastr.error('Erro ao salvar operação', 'Erro!');
        },
      });
    }
  }

  removeTitle(id: number) {
    this.financialReleaseList.splice(id, 1);
  }

  editTitle(financialRelease: FinancialReleaseModel, index: number) {
    this.financialReleaseForm.setValue({
      ...financialRelease,
      releaseDate: new Date(financialRelease.releaseDate),
      dueDate: new Date(financialRelease.dueDate),
    });
    this.currentTitle = index + 1;
  }
  calculateTotal() {
    return this.financialReleaseList.reduce((previous, current) => {
      return previous + (current.amount - current.discount);
    }, 0);
  }

  cancelTitle() {
    this.router.navigate(['/']);
  }
  public loadOperation(): void {
    this.operationId = +this.activatedRouter.snapshot.params['id'];
    if (
      !isNaN(this.operationId) &&
      this.operationId !== null &&
      this.operationId !== 0
    ) {
      this.operationService.getOperationById(this.operationId).subscribe({
        next: (value: OperationModel) => {
          this.operation = value;
          this.operationForm.setValue(value);
          this.financialReleaseList = value.financialRelease;
        },
        error: (error: any) => {
          console.error(error);
        },
      });
    }
  }
}
