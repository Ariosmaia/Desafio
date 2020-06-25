import { Employee } from './employee.model';

export class Pagination {
  constructor(
    public total: number,
    public totalPages: number,
    public sizePage: number,
    public numberPage: number,
    public result: Employee[],
    public previous: string,
    public next: string
  ){}
}
