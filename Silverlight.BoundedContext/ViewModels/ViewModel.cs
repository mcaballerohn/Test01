using Silverlight.BoundedContext.ServiceWCF;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Silverlight.BoundedContext.ViewModels
{
    public class ViewModel:BaseINPC
    {
        #region Constructor

        public ViewModel()
        {
            _proxy = new ServiceN_CapasClient();
            LlenarPlantas();

        }

        #endregion

        #region Campos y Propiedades 

        private readonly ServiceN_CapasClient _proxy;
      
        private DepartamentosDto _DepartamentoSeleccionado;

        public DepartamentosDto DepartamentoSeleccionado
        {
            get 
            { 
                return _DepartamentoSeleccionado; 
            }
            set 
            {
                if (_DepartamentoSeleccionado == value) return;
                _DepartamentoSeleccionado = value;
                RaisePropertyChanged("DepartamentoSeleccionado");
            }
        }

        private PlantaDto _plantaSeleccionada;

        public PlantaDto PlantaSeleccionada
        {
            get 
            { 
                return _plantaSeleccionada; 
            }
            set 
            {
                if (_plantaSeleccionada == value) return;
                _plantaSeleccionada = value;
                RaisePropertyChanged("PlantaSeleccionada");
            }
        }

        private ProcesosPorDepartamentosDto _procesosPorDepto;

        public ProcesosPorDepartamentosDto ProcesosPorDepto
        {
            get 
            {
                return _procesosPorDepto; 
            }
            set 
            {
                if (_procesosPorDepto == value) return;
                _procesosPorDepto = value;
                RaisePropertyChanged("ProcesosPorDepto");
            }
        }


        private ObservableCollection<PlantaDto> _listaPlanta;

        public ObservableCollection<PlantaDto> ListaPlantas
        {
            get { return _listaPlanta; }
            set 
            {
                if (_listaPlanta == value) return;
                _listaPlanta = value;
                RaisePropertyChanged("ListaPlantas");
            }
        }

        private ObservableCollection<DepartamentosDto> _listaDepartamento;

        public ObservableCollection<DepartamentosDto> ListaDepartamentos
        {
            get { return _listaDepartamento; }
            set 
            {
                if (_listaDepartamento == value) return;
                _listaDepartamento = value;
                RaisePropertyChanged("ListaDepartamentos");
            }
        }


        #endregion

        #region Metodos

        public void LlenarPlantas()
        {
            _proxy.GetAllPlantasAsync();
            _proxy.GetAllPlantasCompleted += _proxy_GetAllPlantasCompleted;
        }

        private void _proxy_GetAllPlantasCompleted(object sender, GetAllPlantasCompletedEventArgs e)
        {
            ListaPlantas = e.Result;
        }


        #endregion

        #region Comandos 

        

        #endregion

    }
}
