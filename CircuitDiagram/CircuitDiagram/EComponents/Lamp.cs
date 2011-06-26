﻿// Lamp.cs
//
// Circuit Diagram http://circuitdiagram.codeplex.com/
//
// Copyright (C) 2011  Sam Fisher
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace CircuitDiagram.EComponents
{
    public class Lamp : EComponent
    {
        public Size Size
        {
            get { return new Size(EndLocation.X - StartLocation.X, EndLocation.Y - StartLocation.Y); }
        }

        public override Rect BoundingBox
        {
            get
            {
                if (Horizontal)
                    return new Rect(new Point(StartLocation.X, StartLocation.Y - 14), new Size(EndLocation.X - StartLocation.X, 28));
                else
                    return new Rect(new Point(StartLocation.X - 14, StartLocation.Y), new Size(28, EndLocation.Y - StartLocation.Y));
            }
        }

        public Lamp()
        {
        }

        protected override void CustomUpdateLayout()
        {
            ImplementMinimumSize(30f);
        }

        public override void Render(IRenderer dc, Color color)
        {
            if (Horizontal)
            {
                dc.DrawLine(color, 2.0f, StartLocation, new Point(StartLocation.X + Size.Width / 2 - 12d, StartLocation.Y));
                dc.DrawEllipse(Colors.Transparent, color, 2d, new Point(StartLocation.X + Size.Width / 2, StartLocation.Y), 12d, 12d);
                dc.DrawLine(color, 2d, new Point(StartLocation.X + Size.Width / 2 - 8d, StartLocation.Y - 8d), new Point(StartLocation.X + Size.Width / 2 + 8d, StartLocation.Y + 8d));
                dc.DrawLine(color, 2d, new Point(StartLocation.X + Size.Width / 2 + 8d, StartLocation.Y - 8d), new Point(StartLocation.X + Size.Width / 2 - 8d, StartLocation.Y + 8d));
                dc.DrawLine(color, 2.0f, new Point(StartLocation.X + Size.Width / 2 + 12d, StartLocation.Y), EndLocation);
            }
            else
            {
                dc.DrawLine(color, 2.0f, StartLocation, new Point(StartLocation.X, StartLocation.Y + Size.Height / 2 - 12d));
                dc.DrawEllipse(Colors.Transparent, color, 2d, new Point(StartLocation.X, StartLocation.Y + Size.Height / 2), 12d, 12d);
                dc.DrawLine(color, 2d, new Point(StartLocation.X - 8d, StartLocation.Y + Size.Height / 2 - 8d), new Point(StartLocation.X + 8d, StartLocation.Y + Size.Height / 2 + 8d));
                dc.DrawLine(color, 2d, new Point(StartLocation.X + 8d, StartLocation.Y + Size.Height / 2 - 8d), new Point(StartLocation.X - 8d, StartLocation.Y + Size.Height / 2 + 8d));
                dc.DrawLine(color, 2.0f, new Point(StartLocation.X, StartLocation.Y + Size.Height / 2 + 12d), EndLocation);
            }
        }
    }
}