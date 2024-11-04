using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukoTest.Model
{
    public static  class EnumColors
    {
        public enum CellValidationColor
        {
            Valid,
            Invalid,
            Warning,
        }
        public static Color GetColorFromEnum(CellValidationColor color)
        {
            switch (color)
            {
                case CellValidationColor.Valid:
                    return Color.White;
                case CellValidationColor.Invalid:
                    return Color.OrangeRed;
                case CellValidationColor.Warning:
                    return Color.LightBlue;
                default:
                    return Color.White;
            }

        }
        public static void SetCellColor(DataGridViewCell cell, CellValidationColor color)
        {
            cell.Style.BackColor = GetColorFromEnum(color);
        }

    }



}
