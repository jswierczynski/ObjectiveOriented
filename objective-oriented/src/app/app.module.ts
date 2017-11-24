import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ObjectivesComponent } from './objectives/objectives.component';
import { HttpModule } from '@angular/http';
import { ObjectivesService } from './services/objectives.service';

@NgModule({
  declarations: [
    AppComponent,
    ObjectivesComponent
  ],
  imports: [
    BrowserModule,
    HttpModule
  ],
  providers: [
    ObjectivesService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
