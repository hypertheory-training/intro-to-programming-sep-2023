import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { isOdd } from "src/app/utils";

@Component({
  selector: "app-home",
  standalone: true,
  imports: [CommonModule],
  template: `
    <p>This is our dashboard for the app.</p>
    <button class="btn btn-primary" (click)="doIt()">
      Click Me For a Good Time
    </button>
  `,
  styles: [],
})
export class HomeComponent {
  doIt() {
    console.log(isOdd(15));
  }
}
