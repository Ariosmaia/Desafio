import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from 'src/app/services/employee.service';
import { Pagination } from 'src/app/models/pagination.model';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';
import { switchMap, debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { Filter } from 'src/app/models/filter.model';

@Component({
  selector: 'app-list-employees',
  templateUrl: './list-employees.component.html',
  styleUrls: ['./list-employees.component.css']
})


export class ListEmployeesComponent implements OnInit {

  public employees: Employee[] = []
  public pagination: Pagination;
  public filter: Filter
  errorMessage: string;

  searchForm: FormGroup

  constructor(
    private employeeService: EmployeeService,
    private fb: FormBuilder
    ) { }

  ngOnInit(): void {
    this.searchForm = this.fb.group({
      search: '',
      filter: ''
    });

    this.handleData();
  }

  handleData(page?: string){
    this.employeeService.getAll(page)
      .subscribe(
        data => {this.employees = data.result, this.pagination = data},
        error => this.errorMessage = error
      );
  }

  handleChangePage(page: number){
    this.handleData(String(page));
  }

  handleFilter(){
    let filterValues:Filter = Object.assign({}, this.filter, this.searchForm.value);

    console.log(filterValues)

    this.employeeService.getAllFilter(filterValues)
      .subscribe(
        data => {this.employees = data.result, this.pagination = data},
        error => this.errorMessage = error
      );
  }

}
