import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConstantsService {

  constructor() { }
  readonly baseAppUrl: string = 'https://localhost:44340/api';
  
}
