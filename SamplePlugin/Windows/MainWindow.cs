using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;
using ImGuiScene;

namespace SamplePlugin.Windows;

public class MainWindow : Window, IDisposable
{
    private TextureWrap GoatImage;
    private Plugin Plugin;

    public MainWindow(Plugin plugin, TextureWrap img) : base(
        "Main settings", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        this.SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(375, 330),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        this.GoatImage = img;
        this.Plugin = plugin;
    }

    public void Dispose()
    {
        this.GoatImage.Dispose();
    }

    public override void Draw()
    {
        ImGui.Text($"The random config bool is {this.Plugin.Configuration.SomePropertyToBeSavedAndWithADefault}");
        ImGui.Text("I am randomly addings things");
        ImGui.BeginListBox("things");
        //ImGui.ListBox("Options", 1,{ "First, Sencond, Tird"},3);
        ImGui.EndListBox();


        if (ImGui.Button("Show Settings"))
        {
            this.Plugin.DrawConfigUI();
        }

        ImGui.Spacing();

        ImGui.Text("Have a pictore:");
        ImGui.Indent(55);
        ImGui.Image(this.GoatImage.ImGuiHandle, new Vector2(this.GoatImage.Width, this.GoatImage.Height));
        ImGui.Unindent(55);
    }
}
