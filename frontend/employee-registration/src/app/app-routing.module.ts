import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListEmployeesComponent } from './pages/list-employees/list-employees.component';
import { AddEmployeeComponent } from './pages/add-employee/add-employee.component';
import { UpdateEmployeeComponent } from './pages/update-employee/update-employee.component';


const routes: Routes = [
  {path: '', component: ListEmployeesComponent},
  {path: 'employee', component: ListEmployeesComponent},
  {path: 'register-employee', component: AddEmployeeComponent},
  {path: 'update-employee/:id', component: UpdateEmployeeComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
exports: [RouterModule]
})
export class AppRoutingModule { }
