// <copyright file="Form1.Designer.cs" company="NematMusaev"> 
// Copyright (c) PlaceholderCompany. All rights reserved. 
// </copyright>
namespace CatchTheButton;

partial class GameFrom
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>s
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">Need to eliminate managed tasks</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Immutable method for Designer support
    /// </summary>
    private void InitializeComponent()
    {
        button = new Button();
        // 
        // button
        // 
        button.Location = new Point(200, 200);
        button.Name = "button";
        button.Size = new Size(100, 100);
        button.TabIndex = 0;
        button.UseVisualStyleBackColor = true;
        button.MouseMove += MouseMoveUnderButton;
        button.Click += ClickButton;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 453);
        Controls.Add(button);
        MinimumSize = new Size(500, 500);
        Name = "Form1";
        Text = "Catch the button";
        ResumeLayout(false);
    }

    #endregion

    private Button button;
}