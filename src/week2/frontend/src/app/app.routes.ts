import { Routes } from "@angular/router";
import { HomeComponent } from "./pages/home/home.component";
import { SupportComponent } from "./pages/support/support.component";

export const routes: Routes = [
  {
    path: "dashboard",
    component: HomeComponent,
  },
  {
    path: "support",
    component: SupportComponent,
  },
  {
    path: "**",
    redirectTo: "dashboard",
  },
];
