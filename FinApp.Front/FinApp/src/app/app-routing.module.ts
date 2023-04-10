import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListOperationComponent } from './components/list-operation/list-operation.component';
import { OperationComponent } from './components/operation/operation.component';
import { ErrorPageComponent } from './components/error-page/error-page.component';
import { StatusOperationComponent } from './components/status-operation/status-operation.component';

const routes: Routes = [
  { path: '', component: ListOperationComponent },
  { path: 'list-operation', component: ListOperationComponent },
  { path: 'operation', component: OperationComponent },
  { path: 'operation/:id', component: OperationComponent },
  { path: 'status/:id', component: StatusOperationComponent },
  { path: '**', component: ErrorPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
