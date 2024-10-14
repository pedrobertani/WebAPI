import { PaginaPrincipalComponent } from './PaginaPrincipal/paginaPrincipal.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'ponto-turistico',
    component: PaginaPrincipalComponent
  },
  {
    path: '**',
    redirectTo: 'ponto-turistico'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
