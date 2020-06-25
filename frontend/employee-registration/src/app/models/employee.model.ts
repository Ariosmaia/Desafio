import { Skill } from './skills.model';

export class Employee {
  constructor(
    public id: string,
    public firstName: string,
    public lastName: string,
    public birthDate: Date,
    public email: string,
    public gender: string,
    public skills: Skill[] = []
  ){}
}
