import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ObjectivesComponent } from './objectives/objectives.component';
import { HttpModule } from '@angular/http';
import { ObjectivesService } from './services/objectives.service';
import { ErrorHandler } from '@angular/core';
import { AppErrorHandler } from './Common/app-error-handler';
import { HttpClientModule } from '@angular/common/http';
import { ObjectiveFormComponent } from './objective-form/objective-form.component';

@NgModule({
  declarations: [
    AppComponent,
    ObjectivesComponent
  ],
  imports: [
    BrowserModule,
    //HttpModule
    HttpClientModule
  ],
  providers: [
    ObjectivesService,
    {
      provide: ErrorHandler,
      useClass: AppErrorHandler
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
