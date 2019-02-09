import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '',
        data: {
            title: 'Bank',
            status: false
        },
        children: [
            {
                path: 'bankreg',
                loadChildren: './bankreg/bankreg.module#BankRegModule'
            },
            {
                path: 'transaction',
                loadChildren: './transaction/transaction.module#TransactionModule'
            },
            {
                path: 'tds',
                loadChildren: './tds/tds.module#TdsModule'
            },
            {
                path: 'group',
                loadChildren: './group/group.module#GroupModule'
            },
            {
                path: 'accountcode',
                loadChildren: './accountcode/accountcode.module#AccountCodeModule'
            },
            {
                path: 'ledgerSubledger',
                loadChildren: './ledger-subledger/ledger-subledger.module#LedgerSubledgerModule'
            },
            {
                path: 'chartofaccount',
                loadChildren: './chartofaccount/chartofaccount.modules#ChartofaccountModule'
            },
            {
                path: 'raisedraftindent',
                loadChildren: './raise-draft-indent/raise-draft-indent.module#RaiseDraftIndentModule'
            },
             {
                 path:'kpems',
                 loadChildren:'./kpems/kpems.module#KpemsModule'
             },    
             {
                path:'mrn',
                loadChildren:'./mrn/mrn.module#MRNModule'
            },         
            
            {
                path:'mrs',
                loadChildren:'./mrs/mrs.module#MRSModule'
            }
                        ]
                }
            ];

            @NgModule({
                imports: [RouterModule.forChild(routes)],
                exports: [RouterModule]
            })
            export class BankRoutingModule { }
