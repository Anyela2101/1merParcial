import { ClienteRegistroComponent} from './Credito/cliente-registro/cliente-registro.component';
import { ClienteConsultaComponent} from './Credito/cliente-consulta/cliente-consulta.component';
import { NgModule, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule} from '@angular/router';

const routes:Routes=[
  {
    path:'clienteConsulta',
    component: ClienteConsultaComponent
  },

  {
    path:'clienteRegistro',
    component: ClienteRegistroComponent
  }

];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
