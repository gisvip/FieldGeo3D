﻿using System.Collections.Generic;
using FGeo3D.GoCAD;
using TerraExplorerX;
using YWCH.CHIDI.DZ.COM.Skyline;

namespace FGeo3D_TE.DrawingObjs
{
    using System;
    using System.Windows.Forms;

    using FGeo3D.GeoObj;

    class DrawingLine : DrawingObject
    {
        
        public DrawingLine(ITerraExplorerObject66 inLine, ITerrainLabel66 inLabel, string markerType, List<string> conObjGuids )
        {
            Type = "Line";
            SkylineObj = inLine;
            SkylineLabel = inLabel;
            MarkerType = markerType;
            ConnObjGuids = conObjGuids;
            Ts = new TsFile(inLine, Type, "PLine", "X", MarkerType, Name, conObjGuids);
            Ts.WriteTsFile();
        }

        /// <summary>
        /// 获取线段点集的中点
        /// </summary>
        /// <returns></returns>
        public Point MidPoint()
        {
            List<Point> pointsList = this.GetPointsList();
            double xSum = 0.0, ySum = 0.0, zSum = 0.0;
            foreach (var p in pointsList)
            {
                xSum += p.X;
                ySum += p.Y;
                zSum += p.Z;
            }
            return new Point(xSum / pointsList.Count, ySum / pointsList.Count, zSum / pointsList.Count);
        }


        /// <summary>
        /// 判断该线是否成环
        /// </summary>
        /// <returns></returns>
        public bool IsRing()
        {
            var tePolyline = this.SkylineObj as ITerrainPolyline66;
            var lineString = tePolyline.Geometry as ILineString;
            bool isClosed = false;
            try
            {
                lineString.IsClosed(ref isClosed);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return isClosed;
        }

        /// <summary>
        /// 线的点集列表
        /// </summary>
        /// <returns></returns>
        public List<Point> GetPointsList()
        {
            var tePolyline = this.SkylineObj as ITerrainPolyline66;
            var lineString = tePolyline.Geometry as ILineString;
            var pointList = new List<Point>();
            for (int i = 0; i < lineString.NumPoints; ++i)
            {
                IPoint p = lineString.Points[i] as IPoint;
                pointList.Add(new Point(p));
            }
            return pointList;
        }

        public override void Store(string dataSourceObjGuid, ref YWCHEntEx db)
        {
            base.Store(dataSourceObjGuid, ref db);

            
        }
    }
}
