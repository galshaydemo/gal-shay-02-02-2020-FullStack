import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConstantsService {

  constructor() { }
  readonly baseAppUrl: string = 'http://localhost:4200/api';
  
}
