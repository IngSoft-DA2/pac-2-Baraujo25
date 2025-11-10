import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { CounterService } from '../services/counter.service';

export const reflectionGuard: CanActivateFn = (route, state) => {
  const counterService = inject(CounterService);
  const router = inject(Router);
  
  counterService.incrementCounter();
  const currentCount = counterService.getCounter();
  
  if (currentCount > 20) {
    alert('Has alcanzado el límite máximo de accesos (20) a esta página.');
    router.navigate(['/']);
    return false;
  }
  
  return true;
};

