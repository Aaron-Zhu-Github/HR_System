import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { VisaStatus } from '../enum/visa-status';

@Injectable({
  providedIn: 'root'
})
export class StatusService {
  private statusSubject = new BehaviorSubject<string>('');
  private nameSubject = new BehaviorSubject<string>('');
  constructor() { }

  setStatus(status: string) {
    this.statusSubject.next(status);
  }

  getStatus(): Observable<string> {
    return this.statusSubject.asObservable();
  }

  setName(name: string) {
    this.nameSubject.next(name);
  }

  getName(): Observable<string> {
    return this.nameSubject.asObservable();
  }
}
