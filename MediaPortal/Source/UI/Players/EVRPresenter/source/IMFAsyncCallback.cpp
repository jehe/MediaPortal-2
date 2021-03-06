// Copyright (C) 2007-2014 Team MediaPortal
// http://www.team-mediaportal.com
// 
// This file is part of MediaPortal 2
// 
// MediaPortal 2 is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// MediaPortal 2 is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with MediaPortal 2. If not, see <http://www.gnu.org/licenses/>.

#include "EVRCustomPresenter.h"

// IMFAsyncCallback Interface http://msdn.microsoft.com/en-us/library/ms699856(v=VS.85).aspx
// Callback interface to notify the application when an asynchronous method completes

// Provides configuration information to the dispatching thread for a callback
HRESULT STDMETHODCALLTYPE EVRCustomPresenter::GetParameters(DWORD *pdwFlags, DWORD *pdwQueue)
{
  return 0;
}


// Called when an asynchronous operation is completed.
HRESULT STDMETHODCALLTYPE EVRCustomPresenter::Invoke(IMFAsyncResult *pAsyncResult)
{
  return 0;
}

