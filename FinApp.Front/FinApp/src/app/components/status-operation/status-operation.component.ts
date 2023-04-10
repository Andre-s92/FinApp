import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OperationModel } from 'src/app/models/operationModel';
import { OperationService } from 'src/app/services/operation.service';

@Component({
  selector: 'app-status-operation',
  templateUrl: './status-operation.component.html',
  styleUrls: ['./status-operation.component.scss']
})
export class StatusOperationComponent implements OnInit {
  operation: OperationModel = {} as OperationModel;
  constructor(
    private operationService: OperationService,
    private router: Router,
    private activatedRouter: ActivatedRoute
    ) { }

  ngOnInit() {
    this.loadOperation();
  }
  public loadOperation(): void {
    const operationId = +this.activatedRouter.snapshot.params['id'];
    if (
      !isNaN(operationId) &&
      operationId !== null &&
      operationId !== 0
    ) {
      this.operationService.getOperationById(operationId).subscribe({
        next: (value: OperationModel) => {
          this.operation = value;
        },
        error: (error: any) => {
          console.error(error);
        },
      });
    }
  }
  backToHome() {
    this.router.navigate(['/']);
  }
  calculateTotal() {
    return this.operation.financialRelease.reduce((previous, current) => {
      return previous + (current.amount - current.discount);
    }, 0);
  }

}
