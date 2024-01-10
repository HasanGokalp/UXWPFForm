Imports DevExpress.Mvvm.Native

Public Class CarService
    Public Property Cars As DXObservableCollection(Of Car) = New DXObservableCollection(Of Car) From {New Car With {
    .Id = 1,
    .Name = "BMW"
    }, New Car With {
    .Name = "MERCEDES",
    .Id = 2
    }, New Car With {
    .Name = "MERCEDES",
    .Id = 3
    }, New Car With {
    .Name = "MERCEDES",
    .Id = 4
    }, New Car With {
    .Name = "BMW",
    .Id = 5
    }, New Car With {
    .Name = "BMW",
    .Id = 6
    }, New Car With {
    .Name = "BMW-X90",
    .Id = 7
    }}

    Public Sub New()

    End Sub

    Public Function GetAllCar() As DXObservableCollection(Of Car)
        Return Cars
    End Function
End Class
