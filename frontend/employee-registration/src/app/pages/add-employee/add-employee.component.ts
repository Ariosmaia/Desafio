import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { Skill } from './../../models/skills.model';
import { FormGroup, FormBuilder, FormControl, FormArray } from '@angular/forms';
import { Employee } from 'src/app/models/employee.model';

import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {


  public skills: Skill[] = [];
  public employee: Employee;
  public errors: any[] = [];
  public employeeForm: FormGroup;


  constructor(private router: Router, private employeeService: EmployeeService, private fb: FormBuilder, private toastr: ToastrService,) { }

  ngOnInit(): void {

    this.handleData();

  }

  handleData(){
    this.employeeService.getAllSkills()
       .subscribe(
         data => {this.onFetchComplete(data)},
         error => this.errors = error
       );
   }

   onFetchComplete(data){
     this.skills = data

     this.employeeForm = this.fb.group({
       firstName: [''],
       lastName: [''],
       email: [''],
       birthDate: '',
       gender: '',
       skills: this.buildSkills(),
     });
   }

  buildSkills(){

    const values = this.skills.map(v => new FormControl(false));

    return this.fb.array(values);
  }

  getSkillsControls() {
    return this.employeeForm.get('skills') ? (<FormArray>this.employeeForm.get('skills')).controls : null;
  }

  addEmployee(){
    let valueSubmit = Object.assign({}, this.employee, this.employeeForm.value);

    console.log(valueSubmit);

    valueSubmit = Object.assign(valueSubmit, {
      skills: valueSubmit.skills
      .map((v, i) => v ? this.skills[i] : null)
      .filter(v => v !== null)
    });



    this.employeeService.registerEmployee(valueSubmit)
        .subscribe(
          result => { this.onSaveComplete() },
          fail => { this.onError(fail) }
        );

  }

  onError(fail) {
    this.errors = fail.error.errors;
    console.log(this.errors);
    this.toastr.error('Ocorreu um erro no processamento', 'Ops! :(');
  }

  onSaveComplete() {

    this.employeeForm.reset();
    this.errors = [];

    const toast = this.toastr.success('Funcionário Registrado com Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/employee']);
      });
    }
  }


}
