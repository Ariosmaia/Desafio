import { Component, OnInit } from '@angular/core';
import { Skill } from 'src/app/models/skills.model';
import { Employee } from 'src/app/models/employee.model';
import { FormGroup, FormBuilder, FormControl, FormArray } from '@angular/forms';
import { EmployeeService } from 'src/app/services/employee.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import convertDate from './../../utils/convert-date.util';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.css']
})
export class UpdateEmployeeComponent implements OnInit {

  public skills: Employee[] = [];
  public employee: Employee;
  public errors: any[] = [];
  public employeeForm: FormGroup;
  public sub: Subscription;
  public employeeId: string = "";


  constructor(private route: ActivatedRoute, private router: Router, private employeeService: EmployeeService, private fb: FormBuilder, private toastr: ToastrService,) { }

  ngOnInit(): void {
    this.handleSkills();
  }

  handleSkills() {
    this.employeeService.getAllSkills()
       .subscribe(
         data => {this.onFetchComplete(data)},
         error => this.errors = error
       );
  }

   buildSkills(){

    const values = this.skills.map(v => new FormControl(false));

    return this.fb.array(values);
  }

  getSkillsControls() {
    return this.employeeForm.get('skills') ? (<FormArray>this.employeeForm.get('skills')).controls : null;
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

    this.sub = this.route.params.subscribe(
      params => {
        this.employeeId = params['id'];
        this.handleData(this.employeeId, data);
      }
    );
  }


  handleData(id, skill){
    console.log(id)
    this.employeeService.getById(id)
       .subscribe(
         data => {this.fillFormEmployeer(data, skill)},
         error => this.errors = error
       );
   }


  fillFormEmployeer(data, skill: Skill[]) {
    this.employee = data;

    this.employee = Object.assign(this.employee, {
      skills: skill
      .map((v, i) => {
        let skillId = this.employee.skills.find(i => i.id === v.id)
        if(!skillId) return false;
        return true;
      })
    });

    console.log(this.employee)

    this.employeeForm.patchValue({
      firstName: this.employee.firstName,
      lastName: this.employee.lastName,
      email: this.employee.email,
      birthDate: convertDate(this.employee.birthDate).iso,
      gender: this.employee.gender,
      skills: this.employee.skills
    });
  }

  updateEmployee(){
    let valueSubmit = Object.assign({}, this.employee, this.employeeForm.value);

    console.log(valueSubmit);

    valueSubmit = Object.assign(valueSubmit, {
      skills: valueSubmit.skills
      .map((v, i) => v ? this.skills[i] : null)
      .filter(v => v !== null)
    });



    this.employeeService.updateEmployee(valueSubmit)
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

    this.errors = [];

    const toast = this.toastr.success('Funcionário Atualizado com Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/employee']);
      });
    }
  }

  handleDelete(){

    if (confirm("Tem certeza que deseja deletar?")){
      this.employeeService.deleteEmployee(this.employeeId).subscribe(
        result => {this.router.navigate(['/employee']);}
      );

    }

  }
}
