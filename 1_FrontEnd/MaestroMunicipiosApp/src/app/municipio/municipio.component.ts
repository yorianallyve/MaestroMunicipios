import { Component, OnInit } from '@angular/core';
import {DepartamentoService} from '../services/departamento.service';
import {PaisService} from '../services/pais.service';
import {MunicipioService} from '../services/municipio.service';
import {Departamento} from '../models/departamento';
import {Pais} from '../models/pais';
import {Municipio} from '../models/municipio';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-municipio',
  templateUrl: './municipio.component.html',
  styleUrls: ['./municipio.component.css'],
  providers: [MunicipioService, DepartamentoService, PaisService]
})
export class MunicipioComponent implements OnInit {

  public ltspaises:Pais[]=[];
  public ltsdepartamentos:Departamento[]=[];
  public ltsmunicipios:Municipio[]=[];
  public ltstempdepartamentos:Departamento[]=[];
  public municipios: Municipio = new Municipio(0,"",0,"",0,"");
  public tempmunicipios: Municipio = new Municipio(0,"",0,"",0,"");
  NotificationStatus: boolean = false;
  TypeNotification: string = "success";
  TextNotification: string = "";
  ModalNotificationStatus: boolean = false;
  ModalTypeNotification: string = "success";
  ModalTextNotification: string = "";
  public active = true;
  public submitted = false;

  constructor(
    private _municipioservice: MunicipioService,
    private _departamentoservice: DepartamentoService,
    private _paisservice: PaisService,
    private modalService: NgbModal
  ) { }

  ngOnInit() {
    this.getmunicipios();
    this.getpaises();
  }

  getpaises() {
    this._paisservice.GetPaisAll().subscribe(result => {
      this.ltspaises = result;
      console.log(this.ltspaises);
    }),
      error => console.error(error);
  }

  getmunicipios() {
    this._municipioservice.GetMunicipioAll().subscribe(result => {
      this.ltsmunicipios = result;
      console.log(this.ltspaises);
    }),
      error => console.error(error);
  }

  getDepartamentos() {
    this._departamentoservice.GetDepartamentoAll().subscribe(result => {
      this.ltspaises = result;
      console.log(this.ltspaises);
    }),
      error => console.error(error);
  }

  onClickInsertMunicipio() {
    this._municipioservice.InsertMunicipio(this.municipios).subscribe(
      result => {
        console.log(result);
        if (result.CodeError == 0) {
          this.NotificationStatus = true;
          this.TextNotification = result.DescriptionError;
          this.TypeNotification = "success";
        } else {
          this.NotificationStatus = true;
          this.TextNotification = result.DescriptionError;
          this.TypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }


  onClickUpdateMunicipio() {
    this._municipioservice.UpdateMunicipio(this.tempmunicipios).subscribe(
      result => {
        console.log(result);
        if (result.CodeError == 0) {
          this.ModalNotificationStatus = true;
          this.ModalTextNotification = result.DescriptionError;
          this.ModalTypeNotification = "success";
          this.getmunicipios();
        } else {
          this.ModalNotificationStatus = true;
          this.ModalTextNotification = result.DescriptionError;
          this.ModalTypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }

  onClickSearchMunicipioId() {
    this._municipioservice.SearchMunicipioId(this.municipios.MunicipioId).subscribe(
      result => {
        console.log(result);
        if (result != null) {
          this.municipios.MunicipioId = result.MunicipioId;
          this.municipios.Nombre = result.Nombre;
          this.municipios.DepartamentoId = result.DepartamentoId;
          this.municipios.NombreDepto = result.NombreDepto;
          this.municipios.PaisId = result.PaisId;
          this.municipios.NombrePais = result.NombrePais;  
        } else {
          this.NotificationStatus = true;
          this.TextNotification = "El municipio no existe";
          this.TypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }

  onClickDeteleMunicipio(IdMunicipio) {
    this._municipioservice.DeleteMunicipio(IdMunicipio).subscribe(
      result => {
        console.log(result);
        if (result.CodeError == 0) {
          this.NotificationStatus = true;
          this.TextNotification = result.DescriptionError;
          this.TypeNotification = "success";
          this.getmunicipios();
        } else {
          this.NotificationStatus = true;
          this.TextNotification = result.DescriptionError;
          this.TypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }

  onClickGetMunicipioAll() {
    this._municipioservice.GetMunicipioAll().subscribe(
      result => {
        console.log(result);
        if (result != null) {
          this.municipios.MunicipioId = result.MunicipioId;
          this.municipios.Nombre = result.Nombre;
          this.municipios.DepartamentoId = result.DepartamentoId;
          this.municipios.NombreDepto = result.NombreDepto;
          this.municipios.PaisId = result.PaisId;
          this.municipios.NombrePais = result.NombrePais; 
        } else {
          this.NotificationStatus = true;
          this.TextNotification = "El municipio no existe";
          this.TypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }

  
  OnClickCleanMunicipios() {
    this.municipios = {
      MunicipioId: 0,
      Nombre: "",
      DepartamentoId:0,
      NombreDepto:"",
      PaisId:0,
      NombrePais:""     
    };
  }

  onChangePais(PaisId) {  

    this._departamentoservice.SearchDepartamentosbyPaisId(PaisId).subscribe(result => {
      this.ltsdepartamentos = result;
    }),
      error => console.error(error);
  }


  onChangePaisTem(PaisId) {  

    this._departamentoservice.SearchDepartamentosbyPaisId(PaisId).subscribe(result => {
      this.ltstempdepartamentos = result;
    }),
      error => console.error(error);
  }
  
  //cerrar notificación
  closeAlert() {
    this.NotificationStatus = !this.NotificationStatus;
  }

    //cerrar notificación Modal
    closeAlertModal() {
      this.ModalNotificationStatus = !this.ModalNotificationStatus;
    }
  


  onClickEditarMunicipio(content,municipio) {
    this.tempmunicipios=municipio;
    this._departamentoservice.SearchDepartamentosbyPaisId(municipio.PaisId).subscribe(result => {
      this.ltstempdepartamentos = result;
      this.modalService.open(content, { size: 'lg' });
    }),
      error => console.error(error);
    
  }
}
