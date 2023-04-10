import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import {OperationComponent} from "./components/operation/operation.component";
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { HttpClientModule } from '@angular/common/http';
import { ListOperationComponent } from './components/list-operation/list-operation.component';
import { StatusOperationComponent } from './components/status-operation/status-operation.component';

@NgModule({
  declarations: [
    AppComponent,
    OperationComponent,
    ListOperationComponent,
    StatusOperationComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ToastrModule.forRoot(),
    AccordionModule.forRoot(),
    BsDatepickerModule.forRoot(),
    HttpClientModule,
    NgxMaskDirective,
    NgxMaskPipe,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [OperationComponent],
  providers: [provideNgxMask()],
  bootstrap: [AppComponent]
})
export class AppModule { }
