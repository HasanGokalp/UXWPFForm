Imports DevExpress.Mvvm.Native

Public Class CarService
    Public Property Cars As DXObservableCollection(Of Car) = New DXObservableCollection(Of Car) From {New Car With {
    .Id = 1,
    .Name = "BMW"
    }, New Car With {
    .Name = "MERCEDES",
    .Id = 2
    }}

    Public Sub New()

    End Sub

    Public Function GetAllCar() As DXObservableCollection(Of Car)
        Return Cars
    End Function
End Class
