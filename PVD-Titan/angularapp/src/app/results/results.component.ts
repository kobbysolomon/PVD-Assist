import { Component } from '@angular/core';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.css']
})
export class ResultsComponent {

  // use .9 and 1.1 of estimate for range. Dummy estimate = 35
  estimate = 35;
  estimate_lower = Math.floor((.9 * this.estimate));
  estimate_higher = Math.floor((1.1 * this.estimate));


}
