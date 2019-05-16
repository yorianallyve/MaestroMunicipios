import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MunicipioComponent } from './municipio/municipio.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './login/login.component';

import {MunicipioService} from './services/municipio.service';
import {DepartamentoService} from './services/departamento.service';
import {PaisService} from './services/pais.service';

@NgModule({
  declarations: [
    AppComponent,
    MunicipioComponent,
    NavbarComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule.forRoot(),
    FormsModule,
    HttpModule,
  ],
  providers: [
    MunicipioService,
    DepartamentoService,
    PaisService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
