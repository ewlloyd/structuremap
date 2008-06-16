using System;
using System.Collections.Generic;

namespace StructureMap.Configuration
{
    public static class TypeReaderFactory
    {
        private static List<ITypeReader> _readers = new List<ITypeReader>();

        static TypeReaderFactory()
        {
            _readers.Add(new DictionaryReader());
            _readers.Add(new PrimitiveArrayReader());
        }

        public static ITypeReader GetReader(Type pluginType)
        {
            foreach (var reader in _readers)
            {
                if (reader.CanProcess(pluginType))
                {
                    return reader;
                }
            }

            return null;
        }
    }
}