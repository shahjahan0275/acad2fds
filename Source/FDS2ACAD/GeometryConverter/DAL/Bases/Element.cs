﻿namespace GeometryConverter.DAL.Bases
{
    public class Element : ElementBase
    {
        public BasePoint Center;
        public string Material { get; set; }
        public int Factor = 1;

        #region Neighbour properties

        /// <summary>
        /// Imagine OX runing from lefts to rights...
        /// Imagine OY runing from you ahead far away...
        /// Imagine OZ runing from ground to skies...
        /// Here are your neighbours:
        /// </summary>
        public int? NeighbourTop { get { return Neighbours[0]; } set { Neighbours[0] = value; } }
        public int? NeighbourBottom { get { return Neighbours[1]; } set { Neighbours[1] = value; } }
        public int? NeighbourFront { get { return Neighbours[2]; } set { Neighbours[2] = value; } }
        public int? NeighbourBack { get { return Neighbours[3]; } set { Neighbours[3] = value; } }
        public int? NeighbourLeft { get { return Neighbours[4]; } set { Neighbours[4] = value; } }
        public int? NeighbourRight { get { return Neighbours[5]; } set { Neighbours[5] = value; } }
        #endregion

        public int?[] Neighbours;

        public int? Index;

        #region Properties

        public double X1 { get { return Center.X - XLength / 2; } }
        public double X2 { get { return Center.X + XLength / 2; } }
        public double Y1 { get { return Center.Y - YLength / 2; } }
        public double Y2 { get { return Center.Y + YLength / 2; } }
        public double Z1 { get { return Center.Z - ZLength / 2; } }
        public double Z2 { get { return Center.Z + ZLength / 2; } }

        #endregion

        #region Properties for FDS

        public double FdsX1 { get { return (Center.X - XLength / 2) / Factor; } }
        public double FdsX2 { get { return (Center.X + XLength / 2) / Factor; } }
        public double FdsY1 { get { return (Center.Y - YLength / 2) / Factor; } }
        public double FdsY2 { get { return (Center.Y + YLength / 2) / Factor; } }
        public double FdsZ1 { get { return (Center.Z - ZLength / 2) / Factor; } }
        public double FdsZ2 { get { return (Center.Z + ZLength / 2) / Factor; } }

        #endregion

        #region Constructors

        public Element(BasePoint center, double xLength, double yLength, double zLength)
            : base(xLength, yLength, zLength)
        {
            Center = center;
            XLength = xLength;
            YLength = yLength;
            ZLength = zLength;
            Material = string.Empty;
            ResetNeighbours();
        }

        public Element(BasePoint center, ElementBase elementBase)
            : base(elementBase.XLength, elementBase.YLength, elementBase.ZLength)
        {
            Center = center;
            XLength = elementBase.XLength;
            YLength = elementBase.YLength;
            ZLength = elementBase.ZLength;
            Material = string.Empty;
            ResetNeighbours();
        }

        public Element(BasePoint[] basePoint)
            : base(basePoint[0].X - basePoint[1].X, basePoint[0].Y - basePoint[1].Y, basePoint[0].Z - basePoint[1].Z)
        {
            Center = new BasePoint(basePoint[0].X - (basePoint[0].X - basePoint[1].X) / 2,
                                   basePoint[0].Y - (basePoint[0].Y - basePoint[1].Y) / 2,
                                   basePoint[0].Z - (basePoint[0].Z - basePoint[1].Z) / 2);
            XLength = (basePoint[0].X - basePoint[1].X);
            YLength = (basePoint[0].Y - basePoint[1].Y);
            ZLength = (basePoint[0].Z - basePoint[1].Z);
            Material = string.Empty;
            ResetNeighbours();

        }

        /// <summary>
        /// Set all neighbourhood relations of current element to null
        /// </summary>
        public void ResetNeighbours()
        {
            Index = null;
            Neighbours = new int?[6];
            NeighbourTop = null;
            NeighbourBottom = null;
            NeighbourFront = null;
            NeighbourBack = null;
            NeighbourLeft = null;
            NeighbourRight = null;
        }

        #endregion


        public void NoNameMethod(Element anotherElement)
        {
            // this coef guaratees that center will fall in the interval
            var k = 1.5;
            if (!((Center.X - anotherElement.Center.X < k * XLength) &&
                    (Center.Y - anotherElement.Center.Y < k * YLength) &&
                    (Center.Z - anotherElement.Center.Z < k * ZLength)))
                return;

            Neighbours[(int)Center.GetPosition(anotherElement.Center) - 1] = anotherElement.Index;
        }
    }
}