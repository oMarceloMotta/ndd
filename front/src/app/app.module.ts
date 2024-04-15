import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HomeComponent } from './home/home.component';
import { TableComponent } from './components/table/table.component';
import { FormComponent } from './components/form/form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ClienteService } from './services/clientes.services';
import { PIPES } from './pipe/index.pipe';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // Importe o módulo MatSnackBarModule

@NgModule({
  declarations: [
    HomeComponent,
    TableComponent,
    FormComponent,
    PIPES
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatSnackBarModule,
    BrowserAnimationsModule,

  ],
  providers: [
    ClienteService,
  ],
  bootstrap: [HomeComponent]
})
export class AppModule { }
