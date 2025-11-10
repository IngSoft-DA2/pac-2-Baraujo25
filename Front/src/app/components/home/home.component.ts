import { Component } from '@angular/core';
import { ConsignaComponent } from '../../shared/components/consigna/consigna.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ConsignaComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}

