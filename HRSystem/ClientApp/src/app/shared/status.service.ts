import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StatusService {
  private statusSubject = new BehaviorSubject<string>('');
  constructor() { }

  setStatus(status: string) {
    this.statusSubject.next(status);
  }

  getStatus(): Observable<string> {
    return this.statusSubject.asObservable();
  }
}
