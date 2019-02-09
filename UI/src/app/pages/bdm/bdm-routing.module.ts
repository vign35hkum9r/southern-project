import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '',
        data: {
            title: 'BDM',
            status: false
        },
        children: [
            {
                path: 'targetsetting',
                loadChildren: './targetsetting/targetsetting.module#TargetSettingModule'
            },
            {
                path: 'leadto',
                loadChildren: './leadto/leadto.module#LeadToModule'
            },
            {
                path: 'mysurvey',
                loadChildren: './mysurvey/mysurvey.module#MySurveyModule'
            }]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class BdmRoutingModule { }
