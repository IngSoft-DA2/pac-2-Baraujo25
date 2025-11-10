import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReflectionService } from '../../services/reflection.service';
import { CounterService } from '../../services/counter.service';

@Component({
  selector: 'app-reflection',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './reflection.component.html',
  styleUrl: './reflection.component.css'
})
export class ReflectionComponent {
  importers: string[] = [];
  isLoading = false;
  isError = false;
  errorMessage = '';

  constructor(
    private reflectionService: ReflectionService,
    public counterService: CounterService
  ) {}

  loadImporters(): void {
    this.isLoading = true;
    this.isError = false;
    this.errorMessage = '';
    this.importers = [];

    this.reflectionService.getImporters().subscribe({
      next: (data) => {
        this.importers = data;
        this.isLoading = false;
      },
      error: (error) => {
        this.isError = true;
        this.errorMessage = error.message || 'Error al cargar los importadores';
        this.isLoading = false;
      }
    });
  }
}

