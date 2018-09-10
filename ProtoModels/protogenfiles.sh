#!/usr/bin/env bash
protoc -I Proto --csharp_out Proto --grpc_out Proto ./Proto/SalaryService.proto --plugin=protoc-gen-grpc=../../../.nuget/packages/grpc.tools/1.14.1/tools/linux_x64/grpc_csharp_plugin
