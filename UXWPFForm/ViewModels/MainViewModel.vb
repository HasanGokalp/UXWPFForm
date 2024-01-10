Imports System.Collections.ObjectModel
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
    Private _search As String
    Public Property Search As String
        Get
            Return _search
        End Get
        Set(value As String)
            _search = value
            FilterByBox()
        End Set
    End Property

    Public Sub New()
        GetAllCommand = New DelegateCommand(AddressOf GetAllCar)
    End Sub

    Public Sub GetAllCar()
        Cars = New CarService().GetAllCar
        RaisePropertiesChanged("Cars")
    End Sub
    <Command>
    Public Sub GetByCar()
        Dim uniqueCars As New DXObservableCollection(Of Car)(
            New CarService().GetAllCar() _
            .GroupBy(Function(c) c.Name) _
            .Select(Function(g) g.First())
            )
        Cars2 = uniqueCars
        RaisePropertiesChanged("Cars2")
    End Sub
    <Command>
    Public Sub GetByName()
        Cars = New DXObservableCollection(Of Car) From {SelectedCarName}
        RaisePropertiesChanged("Cars")
    End Sub
    Public Sub FilterByBox()
        If (String.IsNullOrEmpty(Search) And SelectedCarName Is Nothing) Then

        Else
            'Cars = New DXObservableCollection(Of Car) From {New Car With {
            '.Id = 4,
            '.Name = "Fiat"}}
            'Cars = New DXObservableCollection(Of Car)(Cars.Where(Function(item) item.Name.ToLower().Contains(Search.ToLower())))
            'Cars = New DXObservableCollection(Of Car)(Cars.Where(Function(item) item.Name.ToLower.Equals(SelectedCarName.Name.ToLower, StringComparison.OrdinalIgnoreCase)).Where(Function(c) c.Name.Contains(Search.ToLower)).Select(Function(c) c))
            Dim filteredCars As IEnumerable(Of Car) = Cars

            If SelectedCarName IsNot Nothing Then
                filteredCars = filteredCars.Where(Function(item) item.Name.Equals(SelectedCarName.Name, StringComparison.OrdinalIgnoreCase))
            End If

            If Not String.IsNullOrWhiteSpace(Search) Then
                filteredCars = filteredCars.Where(Function(c) c.Name.ToLower().Contains(Search.ToLower()))
            End If

            Cars = New DXObservableCollection(Of Car)(filteredCars)
            RaisePropertiesChanged("Cars")
        End If
    End Sub
End Class
