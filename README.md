# How-to-add-a-close-button-to-each-tab-header-in-.NET-MAUI-TabView
 
A sample application that demonstrates how to display a close (×) button on each tab header in .NET MAUI TabView, and how to remove tabs dynamically when the button is clicked.You can achieve this by customizing the `HeaderItemTemplate` of `SfTabView` to include a close button. On click, locate the corresponding item and remove it from the bound collection—SfTabView will update automatically.
 
## Prerequisites
 
* Visual Studio 2026 with .NET MAUI workload
 
## How to run this sample
 
1. Clone the repository.
2. Open the solution file `TabViewHeaderCloseButton.sln` in Visual Studio 2026.
3. Build and run the project.
 
## Code Snippet
 
To achieve the glass-like effect, use below code.
 
**Mainpage.Xaml**
 
```xml
   <ContentPage.Resources>
    <Style x:Key="CloseIconButtonStyle" TargetType="core:SfEffectsView">
        <Setter Property="VisualStateManager.VisualStateGroups">
            <Setter.Value>
                <VisualStateGroupList>
                    <VisualStateGroup x:Name="CommonStates">
 
                        <VisualState x:Name="Normal">
                            <VisualState.Setters>
                                <Setter Property="BackgroundColor" Value="Transparent" />
                            </VisualState.Setters>
                        </VisualState>
 
                        <VisualState x:Name="PointerOver">
                            <VisualState.Setters>
                                <Setter Property="BackgroundColor" Value="#E6E6E6" />
                            </VisualState.Setters>
                        </VisualState>
 
                    </VisualStateGroup>
                </VisualStateGroupList>
            </Setter.Value>
        </Setter>
    </Style>
</ContentPage.Resources>
 
 
<tabView:SfTabView ItemsSource="{Binding TabItems}"
               IndicatorPlacement="Fill">
 
    <tabView:SfTabView.HeaderItemTemplate>
        <DataTemplate>
            <Grid Padding="8,4" ColumnSpacing="8">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*" />
                    <ColumnDefinition Width="Auto" />
                </Grid.ColumnDefinitions>
 
                <Label Grid.Column="0" WidthRequest="90"
                   Text="{Binding Title}" HorizontalTextAlignment="Center"
                   VerticalTextAlignment="Center" />
 
                <core:SfEffectsView Grid.Column="1" Style="{StaticResource CloseIconButtonStyle}" HorizontalOptions="End" VerticalOptions="Center"
                WidthRequest="22" HeightRequest="22" >
 
                    <core:SfEffectsView.GestureRecognizers>
                        <TapGestureRecognizer Tapped="TapGestureRecognizer_Tapped" />
                    </core:SfEffectsView.GestureRecognizers>
                    <core:SfEffectsView.Content>
                        <Grid>
                            <Label Text="✕" FontSize="14"  HorizontalTextAlignment="Center" VerticalTextAlignment="Center" TextColor="Black"/>
                        </Grid>
                    </core:SfEffectsView.Content>
                </core:SfEffectsView>
            </Grid>
        </DataTemplate>
    </tabView:SfTabView.HeaderItemTemplate>
 
       <!--ContentItemTemplate-->
 
   </tabView:SfTabView>
 
</ContentPage>
```
 
**Mainpage.Xaml.cs**
 
```xml
private readonly MainPageViewModel viewModel = new MainPageViewModel();
public MainPage()
{
    InitializeComponent();
    BindingContext = viewModel;
}
 
private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
{
    var model = (sender as View)?.BindingContext as Model;
    if (model != null && viewModel.TabItems.Contains(model))
    {
        viewModel.TabItems.Remove(model);
    }
}
```
 
**ViewModel**
 
```xml
public class MainPageViewModel
{
    public ObservableCollection<Model> TabItems { get; set; }
    public MainPageViewModel()
    {
        TabItems = new ObservableCollection<Model>
        {
           new Model
            {
                Title = "Home",
                ContentText = "Welcome to the Home tab. Here you can find an overview of your application and quick access to essential features."
            },
            new Model
            {
                Title = "Tasks",
                ContentText = "Manage your tasks efficiently. Add new tasks, track progress, and stay organized to meet your goals."
            },
            new Model
            {
                Title = "Reports",
                ContentText = "View detailed reports and analytics. Gain insights into your performance and make informed decisions."
            }
        };
    }
 
}
```
 
**Model**
 
```xml
public class Model
{
    public string Title { get; set; }
    public string ContentText { get; set; }
}
```