﻿using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using GeometryConverter.DAL.Bases;

namespace GeometryConverter.DAL
{
    public class BurnerOperator
    {
        private readonly Solid3d _solid;

        public Element Element
        {
            get
            {
                var converter = new SolidToElementConverter(_solid);

                var maxMinPoint = converter.MaxMinPoint;

                return new Element(maxMinPoint);
            }
        }

        public BurnerOperator(Solid3d solid)
        {
            _solid = solid;
        }
    }
}
