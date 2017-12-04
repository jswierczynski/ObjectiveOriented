import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ObjectivesComponent } from './objectives/objectives.component';
import { HttpModule } from '@angular/http';
import { ObjectivesService } from './services/objectives.service';
import { ErrorHandler } from '@angular/core';
import { AppErrorHandler } from './Common/app-error-handler';
import { HttpClientModule } from '@angular/common/http';
import { ObjectiveFormComponent } from './objective-form/objective-form.component';
import { SubtasksComponent } from './subtasks/subtasks.component';
import { ObjectiveComponent } from './objective/objective.component';
import { TaskComponent } from './task/task.component';
import { TasksService } from './services/tasks.service';

@NgModule({
  declarations: [
    AppComponent,
    ObjectivesComponent,
    ObjectiveFormComponent,
    SubtasksComponent,
    ObjectiveComponent,
    TaskComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: ObjectivesComponent },
      { path: 'objective', component: ObjectiveFormComponent }
    ])
  ],
  providers: [
    ObjectivesService,
    TasksService,
    {
      provide: ErrorHandler,
      useClass: AppErrorHandler
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
