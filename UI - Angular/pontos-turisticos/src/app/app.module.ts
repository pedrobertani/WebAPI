import { PaginaPrincipalComponent } from './PaginaPrincipal/paginaPrincipal.component';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { DxDataGridModule, DxSelectBoxModule, DxTemplateModule, DxTextAreaModule, DxTextBoxModule } from 'devextreme-angular';
import { AppComponent } from './app.component';
import { CidadeEstadoComponent } from './cidade-estado/cidade-estado.component';
import { PontoTuristicoComponent } from './ponto-turistico/ponto-turistico.component';



@NgModule({
  declarations: [
    AppComponent,
    CidadeEstadoComponent,
    PaginaPrincipalComponent,
    PontoTuristicoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DxSelectBoxModule,
    DxTextBoxModule,
    DxTemplateModule,
    HttpClientModule,
    DxDataGridModule, 
    DxTextBoxModule,
    DxTextAreaModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
