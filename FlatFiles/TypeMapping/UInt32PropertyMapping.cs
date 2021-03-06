﻿using System;
using System.Globalization;

namespace FlatFiles.TypeMapping
{
    /// <summary>
    /// Represents the mapping from a type property to an unsigned int column.
    /// </summary>
    public interface IUInt32PropertyMapping
    {
        /// <summary>
        /// Sets the name of the column in the input or output file.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IUInt32PropertyMapping ColumnName(string name);

        /// <summary>
        /// Sets the format provider to use.
        /// </summary>
        /// <param name="provider">The provider to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IUInt32PropertyMapping FormatProvider(IFormatProvider provider);

        /// <summary>
        /// Sets the number styles to expect when parsing the input.
        /// </summary>
        /// <param name="styles">The number styles used in the input.</param>
        /// <returns>The property mappig for further configuration.</returns>
        IUInt32PropertyMapping NumberStyles(NumberStyles styles);

        /// <summary>
        /// Sets the output format to use.
        /// </summary>
        /// <param name="format">The format to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IUInt32PropertyMapping OutputFormat(string format);

        /// <summary>
        /// Sets what value(s) are treated as null.
        /// </summary>
        /// <param name="formatter">The formatter to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        /// <remarks>Passing null will cause the default formatter to be used.</remarks>
        IUInt32PropertyMapping NullFormatter(INullFormatter formatter);

        /// <summary>
        /// Sets the default value to use when a null is encountered on a non-null property.
        /// </summary>
        /// <param name="defaultValue">The default value to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        /// <remarks>Passing null will cause an exception to be thrown for unexpected nulls.</remarks>
        IUInt32PropertyMapping DefaultValue(IDefaultValue defaultValue);

        /// <summary>
        /// Sets a function to preprocess in the input before parsing it.
        /// </summary>
        /// <param name="preprocessor">A preprocessor function.</param>
        /// <returns>The property mapping for further configuration.</returns>
        [Obsolete("This function has been superseded by the OnParsing function.")]
        IUInt32PropertyMapping Preprocessor(Func<string, string> preprocessor);

        /// <summary>
        /// Sets the function to run before the input is parsed.
        /// </summary>
        /// <param name="handler">A function to call before the textual value is parsed.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IUInt32PropertyMapping OnParsing(Func<IColumnContext, String, String> handler);

        /// <summary>
        /// Sets the function to run after the input is parsed.
        /// </summary>
        /// <param name="handler">A function to call after the value is parsed.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IUInt32PropertyMapping OnParsed(Func<IColumnContext, object, object> handler);

        /// <summary>
        /// Sets the function to run before the output is formatted as a string.
        /// </summary>1
        /// <param name="handler">A function to call before the value is formatted as a string.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IUInt32PropertyMapping OnFormatting(Func<IColumnContext, object, object> handler);

        /// <summary>
        /// Sets the function to run after the output is formatted as a string.
        /// </summary>
        /// <param name="handler">A function to call after the value is formatted as a string.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IUInt32PropertyMapping OnFormatted(Func<IColumnContext, string, string> handler);
    }

    internal sealed class UInt32PropertyMapping : IUInt32PropertyMapping, IMemberMapping
    {
        private readonly UInt32Column column;

        public UInt32PropertyMapping(UInt32Column column, IMemberAccessor member, int physicalIndex, int logicalIndex)
        {
            this.column = column;
            Member = member;
            PhysicalIndex = physicalIndex;
            LogicalIndex = logicalIndex;
        }

        public IUInt32PropertyMapping ColumnName(string name)
        {
            column.ColumnName = name;
            return this;
        }

        public IUInt32PropertyMapping FormatProvider(IFormatProvider provider)
        {
            column.FormatProvider = provider;
            return this;
        }

        public IUInt32PropertyMapping NumberStyles(NumberStyles styles)
        {
            column.NumberStyles = styles;
            return this;
        }

        public IUInt32PropertyMapping OutputFormat(string format)
        {
            column.OutputFormat = format;
            return this;
        }

        public IUInt32PropertyMapping NullFormatter(INullFormatter formatter)
        {
            column.NullFormatter = formatter;
            return this;
        }

        public IUInt32PropertyMapping DefaultValue(IDefaultValue defaultValue)
        {
            column.DefaultValue = defaultValue;
            return this;
        }

        public IUInt32PropertyMapping Preprocessor(Func<string, string> preprocessor)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            column.Preprocessor = preprocessor;
#pragma warning restore CS0618 // Type or member is obsolete
            return this;
        }

        public IUInt32PropertyMapping OnParsing(Func<IColumnContext, String, String> handler)
        {
            column.OnParsing = handler;
            return this;
        }

        public IUInt32PropertyMapping OnParsed(Func<IColumnContext, object, object> handler)
        {
            column.OnParsed = handler;
            return this;
        }

        public IUInt32PropertyMapping OnFormatting(Func<IColumnContext, object, object> handler)
        {
            column.OnFormatting = handler;
            return this;
        }

        public IUInt32PropertyMapping OnFormatted(Func<IColumnContext, string, string> handler)
        {
            column.OnFormatted = handler;
            return this;
        }

        public IMemberAccessor Member { get; }

        public Action<IColumnContext, object, object> Reader => null;

        public Action<IColumnContext, object, object[]> Writer => null;

        public IColumnDefinition ColumnDefinition => column;

        public int PhysicalIndex { get; }

        public int LogicalIndex { get; }
    }
}
