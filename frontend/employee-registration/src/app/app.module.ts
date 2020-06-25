import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';

import { NgxFontAwesomeModule } from 'ngx-font-awesome';

import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';

import {NgxPaginationModule} from 'ngx-pagination';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { ListEmployeesComponent } from './pages/list-employees/list-employees.component';
import { EmployeeService } from './services/employee.service';
import { AgePipe } from './pipes/age.pipe';
import { AddEmployeeComponent } from './pages/add-employee/add-employee.component';
import { ErrorHandlerService } from 'src/service/error.handler.service';
import { UpdateEmployeeComponent } from './pages/update-employee/update-employee.component';


@NgModule({
  declarations: [
    AppComponent,
    ListEmployeesComponent,
    AgePipe,
    AddEmployeeComponent,
    UpdateEmployeeComponent,
  ],
  imports: [
  SharedModule,
    BrowserModule,
    AppRoutingModule,
    NgxFontAwesomeModule,
    FormsModule,
    HttpClientModule,
    NgxPaginationModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    CollapseModule.forRoot(),
  ],
  providers: [
    EmployeeService,
    ErrorHandlerService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
