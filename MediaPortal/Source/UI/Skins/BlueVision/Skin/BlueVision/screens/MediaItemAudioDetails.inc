<?xml version="1.0" encoding="utf-8"?>
<Grid
  xmlns="www.team-mediaportal.com/2008/mpf/directx"
  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
  xmlns:fanart="clr-namespace:MediaPortal.Extensions.UserServices.FanArtService.Client;assembly=FanArtService.Client"
  xmlns:media="clr-namespace:MediaPortal.UiComponents.Media.Models.AspectWrappers;assembly=Media"
  xmlns:aspect="clr-namespace:MediaPortal.Common.MediaManagement.DefaultItemAspects;assembly=MediaPortal.Common"
  x:Name="MediaItemDetails" HorizontalAlignment="Stretch" VerticalAlignment="Stretch">

  <Grid.Resources>
    <fanart:FanArtImageSourceConverter x:Key="FanArtImageSourceConverter"/>
    <MultiAspectAttributeConverter x:Key="MultiAspectAttributeConverter"/>
  </Grid.Resources>
  
  <Grid.RowDefinitions>
    <RowDefinition Height="190"/>
  </Grid.RowDefinitions>
  <Grid.ColumnDefinitions>
    <ColumnDefinition Width="1650"/>
    <ColumnDefinition Width="100"/>
  </Grid.ColumnDefinitions>
  
  <WrapPanel Orientation="Vertical" Grid.Column="0" Grid.Row="0">

    <media:AudioAspectWrapper MediaItem="{Binding Source={StaticResource FanArtBackgroundModel},Path=MediaItem}">
      <media:AudioAspectWrapper.Template>
        <ControlTemplate>
          <Grid DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Margin="0,0,20,0">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="200"/>
              <ColumnDefinition Width="450"/>
            </Grid.ColumnDefinitions>
            <Label x:Name="TitleLabel" Grid.Row="0" Grid.Column="0"
                Content="[Media.AudioTitleLabel]" Color="{ThemeResource TextColor}" Opacity="0.6"/>
            <Label x:Name="Title" Grid.Row="0" Grid.Column="1" Scroll="Auto"
                Content="{Binding TrackName}" Color="{ThemeResource TextColor}"/>
          </Grid>
        </ControlTemplate>
      </media:AudioAspectWrapper.Template>
    </media:AudioAspectWrapper>

    <media:AudioAspectWrapper MediaItem="{Binding Source={StaticResource FanArtBackgroundModel},Path=MediaItem}">
      <media:AudioAspectWrapper.Template>
        <ControlTemplate>
          <Grid DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Margin="0,0,20,0">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="200"/>
              <ColumnDefinition Width="450"/>
            </Grid.ColumnDefinitions>

            <Label x:Name="ArtistsLabel" Grid.Row="0" Grid.Column="0"
                Content="[Media.AudioArtistsLabel]" Color="{ThemeResource TextColor}" Opacity="0.6"/>
            <Label x:Name="Artists" Grid.Row="0" Grid.Column="1"
                Content="{Binding Artists}" Color="{ThemeResource TextColor}"/>
          </Grid>
        </ControlTemplate>
      </media:AudioAspectWrapper.Template>
    </media:AudioAspectWrapper>

    <media:AudioAspectWrapper MediaItem="{Binding Source={StaticResource FanArtBackgroundModel},Path=MediaItem}">
      <media:AudioAspectWrapper.Template>
        <ControlTemplate>
          <Grid DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Margin="0,0,20,0">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="200"/>
              <ColumnDefinition Width="450"/>
            </Grid.ColumnDefinitions>            
            <Label x:Name="AlbumLabel" Grid.Row="0" Grid.Column="0"
                Content="[Media.AudioAlbumLabel]" Color="{ThemeResource TextColor}" Opacity="0.6"/>
            <Label x:Name="Album" Grid.Row="0" Grid.Column="1"
                Content="{Binding Album}" Color="{ThemeResource TextColor}"/>
          </Grid>
        </ControlTemplate>
      </media:AudioAspectWrapper.Template>
    </media:AudioAspectWrapper>

    <media:AudioAspectWrapper MediaItem="{Binding Source={StaticResource FanArtBackgroundModel},Path=MediaItem}">
      <media:AudioAspectWrapper.Template>
        <ControlTemplate>
          <Grid DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Margin="0,0,20,0">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="200"/>
              <ColumnDefinition Width="450"/>
            </Grid.ColumnDefinitions>
            <Label x:Name="AlbumArtistsLabel" Grid.Row="0" Grid.Column="0"
                Content="[Media.AudioAlbumArtistsLabel]" Color="{ThemeResource TextColor}" Opacity="0.6"/>
            <Label x:Name="AlbumArtists" Grid.Row="0" Grid.Column="1"
                Content="{Binding Path=AlbumArtists}" Color="{ThemeResource TextColor}"/>
          </Grid>
        </ControlTemplate>
      </media:AudioAspectWrapper.Template>
    </media:AudioAspectWrapper>

    <media:AudioAspectWrapper MediaItem="{Binding Source={StaticResource FanArtBackgroundModel},Path=MediaItem}">
      <media:AudioAspectWrapper.Template>
        <ControlTemplate>
          <Grid DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Margin="0,0,20,0">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="140"/>
              <ColumnDefinition Width="300"/>
            </Grid.ColumnDefinitions>
            <Label x:Name="TrackLabel" Grid.Row="0" Grid.Column="0"
                Content="[Media.AudioTrackLabel]" Color="{ThemeResource TextColor}" Opacity="0.6"/>
            <Label x:Name="Track" Grid.Row="0" Grid.Column="1"
                Content="{Binding Path=Track}" Color="{ThemeResource TextColor}"/>
          </Grid>
        </ControlTemplate>
      </media:AudioAspectWrapper.Template>
    </media:AudioAspectWrapper>

    <media:AudioAspectWrapper MediaItem="{Binding Source={StaticResource FanArtBackgroundModel},Path=MediaItem}">
      <media:AudioAspectWrapper.Template>
        <ControlTemplate>
          <Grid DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Margin="0,0,20,0">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="140"/>
              <ColumnDefinition Width="300"/>
            </Grid.ColumnDefinitions>
            <Label x:Name="DurationLabel" Grid.Row="0" Grid.Column="0"
                Content="[Media.AudioDurationLabel]" Color="{ThemeResource TextColor}" Opacity="0.6"/>
            <Label x:Name="Duration" Grid.Row="0" Grid.Column="1"
                Content="{Binding Path=Duration, Converter={StaticResource DurationConverter}, ConverterParameter=hh\:mm\:ss}" Color="{ThemeResource TextColor}"/>
          </Grid>
        </ControlTemplate>
      </media:AudioAspectWrapper.Template>
    </media:AudioAspectWrapper>   
    
    <media:AudioAspectWrapper MediaItem="{Binding Source={StaticResource FanArtBackgroundModel},Path=MediaItem}">
      <media:AudioAspectWrapper.Template>
        <ControlTemplate>
          <Grid DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Margin="0,0,20,0">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="140"/>
              <ColumnDefinition Width="300"/>
            </Grid.ColumnDefinitions>            
            <Label x:Name="GenresLabel" Grid.Row="0" Grid.Column="0"
                Content="[Media.AudioGenresLabel]" Color="{ThemeResource TextColor}" Opacity="0.6"/>
            <Label x:Name="Genre" TextTrimming="WordEllipsis" Color="{ThemeResource TextColor}"
                   Grid.Row="0" Grid.Column="1">
              <Label.Content>
                <MultiBinding Converter="{StaticResource MultiAspectAttributeConverter}">
                  <Binding Source="{StaticResource FanArtBackgroundModel}" Path="MediaItem"/>
                  <Binding Source="{x:Static aspect:GenreAspect.ATTR_GENRE}" />
                </MultiBinding>
              </Label.Content>
            </Label>
          </Grid>
        </ControlTemplate>
      </media:AudioAspectWrapper.Template>
    </media:AudioAspectWrapper>

    <media:MediaAspectWrapper MediaItem="{Binding Source={StaticResource FanArtBackgroundModel},Path=MediaItem}">
      <media:MediaAspectWrapper.Template>
        <ControlTemplate>
          <Grid DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Margin="0,0,20,0">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="140"/>
              <ColumnDefinition Width="300"/>
            </Grid.ColumnDefinitions>
            <Label x:Name="YearLabel" Grid.Row="0" Grid.Column="0"
                Content="[Media.AudioYearLabel]" Color="{ThemeResource TextColor}" Opacity="0.6"/>
            <Label x:Name="Year" Grid.Row="0" Grid.Column="1"
                Content="{Binding Path=RecordingTime, Converter={StaticResource DateFormatConverter}, ConverterParameter=yyyy}" Color="{ThemeResource TextColor}"/>
          </Grid>
        </ControlTemplate>
      </media:MediaAspectWrapper.Template>
    </media:MediaAspectWrapper>

    <media:AudioAspectWrapper MediaItem="{Binding Source={StaticResource FanArtBackgroundModel},Path=MediaItem}">
      <media:AudioAspectWrapper.Template>
        <ControlTemplate>
          <Grid DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Margin="0,0,20,0">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="170"/>
              <ColumnDefinition Width="300"/>
            </Grid.ColumnDefinitions>           
            <Label x:Name="BitrateLabel" Grid.Row="0" Grid.Column="0"
                Content="[Media.AudioBitRateLabel]" Color="{ThemeResource TextColor}" Opacity="0.6"/>
            <Label x:Name="Bitrate" Grid.Row="0" Grid.Column="1" Color="{ThemeResource TextColor}">
              <Label.Content>
                  <Binding Path="BitRate" Converter="{StaticResource StringFormatConverter}" ConverterParameter="{}{0} kBit"/>
              </Label.Content>
            </Label> 
          </Grid>
        </ControlTemplate>
      </media:AudioAspectWrapper.Template>
    </media:AudioAspectWrapper>

    <media:MediaAspectWrapper MediaItem="{Binding Source={StaticResource FanArtBackgroundModel},Path=MediaItem}">
      <media:MediaAspectWrapper.Template>
        <ControlTemplate>
          <Grid DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Margin="0,0,20,0">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="170"/>
              <ColumnDefinition Width="300"/>
            </Grid.ColumnDefinitions>
            <Label x:Name="ComposersLabel" Grid.Row="0" Grid.Column="0"
                Content="[Media.AudioComposersLabel]" Color="{ThemeResource TextColor}" Opacity="0.6"/>
            <Label x:Name="Composers" Grid.Row="0" Grid.Column="1"
                Content="{Binding Path=Composers}" Color="{ThemeResource TextColor}"/>
          </Grid>
        </ControlTemplate>
      </media:MediaAspectWrapper.Template>
    </media:MediaAspectWrapper>

    <media:MediaAspectWrapper MediaItem="{Binding Source={StaticResource FanArtBackgroundModel},Path=MediaItem}">
      <media:MediaAspectWrapper.Template>
        <ControlTemplate>
          <Grid DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Margin="0,0,20,0">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="170"/>
              <ColumnDefinition Width="300"/>
            </Grid.ColumnDefinitions>
            <Label x:Name="TypeLabel" Grid.Row="0" Grid.Column="0"
                Content="[Media.AudioMimeTypeLabel]" Color="{ThemeResource TextColor}" Opacity="0.6"/>
            <Label x:Name="MimeType" Grid.Row="0" Grid.Column="1"
                Content="{Binding Path=MimeType}" Color="{ThemeResource TextColor}"/>
          </Grid>
        </ControlTemplate>
      </media:MediaAspectWrapper.Template>
    </media:MediaAspectWrapper>

  </WrapPanel>
</Grid>
