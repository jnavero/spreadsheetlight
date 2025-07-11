﻿using System;
using DocumentFormat.OpenXml.Spreadsheet;
using X14 = DocumentFormat.OpenXml.Office2010.Excel;

namespace SpreadsheetLight
{
    internal class SLConditionalFormatValueObject
    {
        internal ConditionalFormatValueObjectValues Type { get; set; }
        internal string Val { get; set; }
        internal bool GreaterThanOrEqual { get; set; }

        internal SLConditionalFormatValueObject()
        {
            this.SetAllNull();
        }

        private void SetAllNull()
        {
            this.Type = ConditionalFormatValueObjectValues.Percentile;
            this.Val = string.Empty;
            this.GreaterThanOrEqual = true;
        }

        internal void FromConditionalFormatValueObject(ConditionalFormatValueObject cfvo)
        {
            this.SetAllNull();

            this.Type = cfvo.Type.Value;
            if (cfvo.Val != null) this.Val = cfvo.Val.Value;
            if (cfvo.GreaterThanOrEqual != null) this.GreaterThanOrEqual = cfvo.GreaterThanOrEqual.Value;
        }

        internal ConditionalFormatValueObject ToConditionalFormatValueObject()
        {
            ConditionalFormatValueObject cfvo = new ConditionalFormatValueObject();
            cfvo.Type = this.Type;

            if (this.Val.Length > 0)
            {
                if (this.Val.StartsWith("=")) cfvo.Val = this.Val.Substring(1);
                else cfvo.Val = this.Val;
            }

            if (!this.GreaterThanOrEqual) cfvo.GreaterThanOrEqual = false;

            return cfvo;
        }

        internal SLConditionalFormattingValueObject2010 ToSLConditionalFormattingValueObject2010()
        {
            SLConditionalFormattingValueObject2010 cfvo2010 = new SLConditionalFormattingValueObject2010();
            cfvo2010.Formula = this.Val;

            if (this.Type == ConditionalFormatValueObjectValues.Formula)
            {
                cfvo2010.Type = X14.ConditionalFormattingValueObjectTypeValues.Formula;
            }
            else if (this.Type == ConditionalFormatValueObjectValues.Max)
            {
                cfvo2010.Type = X14.ConditionalFormattingValueObjectTypeValues.Max;
            }
            else if (this.Type == ConditionalFormatValueObjectValues.Min)
            {
                cfvo2010.Type = X14.ConditionalFormattingValueObjectTypeValues.Min;
            }
            else if (this.Type == ConditionalFormatValueObjectValues.Number)
            {
                cfvo2010.Type = X14.ConditionalFormattingValueObjectTypeValues.Numeric;
            }
            else if (this.Type == ConditionalFormatValueObjectValues.Percent)
            {
                cfvo2010.Type = X14.ConditionalFormattingValueObjectTypeValues.Percent;
            }
            else if (this.Type == ConditionalFormatValueObjectValues.Percentile)
            {
                cfvo2010.Type = X14.ConditionalFormattingValueObjectTypeValues.Percentile;
            }

            cfvo2010.GreaterThanOrEqual = this.GreaterThanOrEqual;

            return cfvo2010;
        }

        internal SLConditionalFormatValueObject Clone()
        {
            SLConditionalFormatValueObject cfvo = new SLConditionalFormatValueObject();
            cfvo.Type = this.Type;
            cfvo.Val = this.Val;
            cfvo.GreaterThanOrEqual = this.GreaterThanOrEqual;

            return cfvo;
        }
    }
}
