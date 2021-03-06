﻿using System;
using Kitware.VTK;

namespace MainWindow
{

    public class DicomLoader
    {
        private vtkDICOMImageReader _dicomReader;

        public DicomLoader(String directoryPath)
        {
            _dicomReader = new vtkDICOMImageReader();
            _dicomReader.SetDirectoryName(directoryPath);
            _dicomReader.Update();
            int a = _dicomReader.GetWidth();
            int b = _dicomReader.GetHeight();
        }

        public void ChangeDirectory(String directoryPath)
        {
            _dicomReader.Dispose();
            _dicomReader = new vtkDICOMImageReader();
            _dicomReader.SetDirectoryName(directoryPath);
            _dicomReader.Update();
        }

        public vtkDataSet GetOutput()
        {
            return _dicomReader.GetOutput();
        }

        public void Dispose()
        {
            _dicomReader.Dispose();
        }
    }
}
