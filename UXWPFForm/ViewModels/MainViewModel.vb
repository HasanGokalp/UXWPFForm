Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Native

Public Class MainViewModel
    Inherits ViewModelBase

    'Commands
    Public Property GetAllCommand As ICommand
    Public Property UpdateCommand As ICommand
    'Public Property GetByNameCommand As ICommand
    'Props
    Public Property Cars As DXObservableCollection(Of Car)
    Public Property Cars2 As DXObservableCollection(Of Car)
    Public Property SelectedCar As Car
    Public Property SelectedCarName As Car

    Public Sub New()
        GetAllCommand = New DelegateCommand(AddressOf GetAllCar)
    End Sub

    Public Sub GetAllCar()
        Cars = New CarService().GetAllCar
        RaisePropertiesChanged("Cars")
    End Sub
    <Command>
    Public Sub GetByCar()
        Cars2 = New CarService().GetAllCar
        RaisePropertiesChanged("Cars2")
    End Sub
    <Command>
    Public Sub GetByName()
        Cars = New DXObservableCollection(Of Car) From {SelectedCarName}
        RaisePropertiesChanged("Cars")
    End Sub
End Class
