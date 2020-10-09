import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AppMaterialModule } from "./app-material/app-material.module";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";

@NgModule({
  declarations: [],
  imports: [CommonModule],
  exports: [AppMaterialModule, NgbModule]
})
export class SharedModule {}
