import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './error-pages/page-not-found/page-not-found.component';
import { AdminComponent } from './features/admin/admin.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';

const routes: Routes = [
  { path: "dashboard", component: DashboardComponent },
  { path: "admin", component: AdminComponent },
  { path: "", component: DashboardComponent, pathMatch: "full" },
  { path: "**", component: PageNotFoundComponent, pathMatch: "full" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
