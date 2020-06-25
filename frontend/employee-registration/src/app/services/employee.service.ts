import { catchError, map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ServiceBase } from './service.base';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';
import { Pagination } from '../models/pagination.model';
import { Skill } from './../models/skills.model';
import { Filter } from './../models/filter.model';

@Injectable()
export class EmployeeService extends ServiceBase{

  constructor(private http: HttpClient) {
    super();
  }

  getAll(
    page: string = "1",
    size: string = "5",
    ): Observable<Pagination>{
    return this.http
      .get<Pagination>(this.UrlServiceV1 + 'employees', {
        params: {
          page: page,
          size: size,
        }
      })
      .pipe(
        catchError(super.serviceError)
      );
  }


  getAllFilter(
    filterValues?: Filter
    ): Observable<Pagination>{
    return this.http
      .get<Pagination>(this.UrlServiceV1 + `employees?${filterValues.filter}=${filterValues.search}`)
      .pipe(
        catchError(super.serviceError)
      );
  }

  getAllSkills(): Observable<Skill[]>{
    return this.http
      .get<Skill[]>(this.UrlServiceV1 + 'skills')
      .pipe(
        catchError(super.serviceError)
      );
  }

  registerEmployee(employee: Employee): Observable<Employee>{
    return this.http
    .post(this.UrlServiceV1 + 'employees', employee)
    .pipe(
      map(super.extractData),
      catchError(super.serviceError)
    );
  }

  getById(id: string): Observable<Employee>{
    return this.http
      .get<Employee>(this.UrlServiceV1 + `employees/${id}`)
      .pipe(
        map(super.extractData),
        catchError(super.serviceError)
      );
  }

  updateEmployee(employee: Employee): Observable<Employee> {
    return this.http
        .put(this.UrlServiceV1 + "employees", employee)
        .pipe(
            map(super.extractData),
            catchError(super.serviceError));
  }

  deleteEmployee(id: string): Observable<Employee> {
    return this.http
        .delete(this.UrlServiceV1 + "employees/" + id)
        .pipe(
            map(super.extractData),
            catchError(super.serviceError));
  }

}
