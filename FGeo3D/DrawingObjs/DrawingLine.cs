﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerraExplorerX;
using YWCH.CHIDI.DZ.COM.Skyline;

namespace FGeo3D_TE
{
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



        public override void Store(string dataSourceObjGuid, ref YWCHEntEx db)
        {
            base.Store(dataSourceObjGuid, ref db);

            
        }
    }
}
