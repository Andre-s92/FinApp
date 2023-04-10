import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { OperationModel } from 'src/app/models/operationModel';
import { OperationService } from 'src/app/services/operation.service';

@Component({
  selector: 'app-list-operation',
  templateUrl: './list-operation.component.html',
  styleUrls: ['./list-operation.component.scss'],
})
export class ListOperationComponent implements OnInit {
  operationList: OperationModel[] = [];

  constructor(
    private operationService: OperationService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.getOperationList();
  }

  getOperationList() {
    this.operationService.getOperation().subscribe({
      next: (value: OperationModel[]) => {
        this.operationList = value;
      },
    });
  }

  newOperation() {
    this.router.navigate(['operation']);
  }
  showOperation(id: number){
    this.router.navigate([`operation/${id}`])
  }
  statusOperation(id: number){
    this.router.navigate([`status/${id}`])
  }
  deleteOperation(id: number){
    this.operationService.deleteOperation(id).subscribe({
      next: (result: any) => {
        this.toastr.success('Operação salva com sucesso!', 'Sucesso');
        const index = this.operationList.findIndex(operation => operation.id == id)
        if(index > 0){
          this.operationList.splice(index,1);
        }


      },
      error: (error: any) =>{
        this.toastr.error('Erro ao excluir operação', 'Erro!');
      },
    });
  }
}
