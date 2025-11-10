import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CounterService {
  private counter = 0;

  incrementCounter(): void {
    this.counter++;
  }

  getCounter(): number {
    return this.counter;
  }

  resetCounter(): void {
    this.counter = 0;
  }
}

